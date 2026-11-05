using MediatR;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Patient;
using System.Text.RegularExpressions;

namespace MisTest.Application.Features.Validation.Patient.CreatePatientValidator
{
    public class CreatePatientValidator : ICreatePatientValidator
    {
        private const int NameMaxLength = 100;
        private const int SurnameMaxLength = 100;
        private const int MiddleNameMaxLength = 100;
        private const int CardNumberMinLength = 4;
        private const int CardNumberMaxLength = 20;
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreatePatient.Error";
        public CreatePatientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreatePatientCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            ValidateName(request.PatientRequestDto.Name, fault);
            ValidateSurname(request.PatientRequestDto.Surname, fault);
            ValidateMiddleName(request.PatientRequestDto.MiddleName, fault);
            ValidateCardNumber(request.PatientRequestDto.CardNumber, fault);

            await ValidateCardNumberUniqueAsync(request.PatientRequestDto.CardNumber, fault);

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }

        private void ValidateName(string name, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                fault.Details.Add(PatientFaults.NameEmpty());
                return;
            }

            if (name.Length > NameMaxLength)
                fault.Details.Add(PatientFaults.NameTooLong(NameMaxLength));
        }

        private void ValidateSurname(string surname, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                fault.Details.Add(PatientFaults.SurnameEmpty());
                return;
            }

            if (surname.Length > SurnameMaxLength)
                fault.Details.Add(PatientFaults.SurnameTooLong(SurnameMaxLength));
        }

        private void ValidateMiddleName(string? middleName, Fault fault)
        {
            if (!string.IsNullOrWhiteSpace(middleName) && middleName.Length > MiddleNameMaxLength)
            {
                fault.Details.Add(PatientFaults.MiddleNameTooLong(MiddleNameMaxLength));
            }
        }

        private void ValidateCardNumber(string cardNumber, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                fault.Details.Add(PatientFaults.CardNumberEmpty());
                return;
            }

            if (!Regex.IsMatch(cardNumber, @"^\d+$"))
            {
                fault.Details.Add(PatientFaults.CardNumberInvalidFormat());
                return;
            }

            if (cardNumber.Length < CardNumberMinLength)
                fault.Details.Add(PatientFaults.CardNumberTooShort(CardNumberMinLength));

            if (cardNumber.Length > CardNumberMaxLength)
                fault.Details.Add(PatientFaults.CardNumberTooLong(CardNumberMaxLength));
        }

        private async Task ValidateCardNumberUniqueAsync(string cardNumber, Fault fault)
        {
            if (await _unitOfWork.PatientRepository.GetPatientAsync(cardNumber) != null)
            {
                fault.Details.Add(PatientFaults.AlreadyExists(cardNumber));
            }
        }
    }
}
