import { AbstractControl } from "@angular/forms";

export function passwordMatchingValidator(c: AbstractControl): {[key: string]: any}{
    let confirmPassword = c.get(['confirmPassword']);
    if(confirmPassword === null) return null;
    let password = c.get(['password']);
    if (password.value !== confirmPassword.value) {
        return { 'passwordsNotMatch': true };
    }
    return null;
}