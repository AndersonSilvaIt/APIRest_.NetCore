﻿using Microsoft.AspNetCore.Identity;

namespace DevIO.Api.Extensions
{
    public class IdentityMensagensPortugues : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Ocorreu um erro desconhecido." }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = $"Falha de concorrência otimista, o objeto foi modificado." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = $"Senha incorreta." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = $"Token inválido." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = $"Já existe um usuário com esse login." }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"Login '{userName}' é inválido, pode conter apenas letras ou digitos" }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Email '{email}' é inválido." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Login '{userName}' já está sendo utilizado." }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Email '{email}' já está sendo utilizado ." }; }
        public override IdentityError InvalidRoleName(string roleName) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"A permissão '{roleName}' é inválida." }; }
        public override IdentityError DuplicateRoleName(string roleName) { return new IdentityError { Code = nameof(DefaultError), Description = $"A permissão '{roleName}' já está sendo utilizada." }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = $"Usuário já possui uma senha definida." }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = $"Lockout não está habilitado para este usuário." }; }
        public override IdentityError UserAlreadyInRole(string roleName) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Usuário já possui a permmissão '{roleName}'." }; }
        public override IdentityError UserNotInRole(string roleName) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"Usuário não tem a permissão '{roleName}'." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Senhas devem conter ao menos {length} caracteres ." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = $"Senhas devem conter ao menos um caractere não alfanumérico." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = $"Senhas devem conter ao menos um dígito ('0'-'9')." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = $"Senhas devem conter ao menos um caractere em caixa baixa ('a' - 'z')." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = $"Senhas devem conter ao menos um caractere em caixa alta ('A'-'Z')." }; }


    }
}