function val() {
    let errors = {};
    let username = document.getElementById("txtUsername").value;
    let password = document.getElementById("txtPassword").value;
    let confirmPassword = document.getElementById("txtConfirmPassword").value;
    let firstname = document.getElementById("txtFirstName").value;
    let lastname = document.getElementById("txtLastName").value;
    let email = document.getElementById("txtEmail").value;
    let phone = document.getElementById("txtPhone").value;
    let gender = document.querySelector('input[name="rblGender"]:checked');
    let hobbies = document.querySelectorAll('input[name="cblHobbies"]:checked');
    let age = document.getElementById("ddlAge").value;
    let teamname = document.getElementById("txtTeamName").value;
    let teamnumber = document.getElementById("txtTeamNumber").value;



 

    if (username.length == 0) errors.username = "Username is required";
    else if (username.length < 4) errors.username = "Username must be at least 4 characters";
    else if (username.indexOf(" ") != -1) errors.username = "Username cannot contain spaces";

    if (password.length == 0) {
        errors.password = "Password is required";
    } else {
        let msg = checkPasswordStrength(password);
        if (msg != "") errors.password = msg;
    }

    if (confirmPassword.length == 0) errors.confirmPassword = "Please confirm your password";
    else if (confirmPassword != password) errors.confirmPassword = "Passwords do not match";

    if (firstname.length == 0) errors.firstname = "First name is required";
    if (lastname.length == 0) errors.lastname = "Last name is required";

    if (email.length == 0) {
        errors.email = "Email is required";
    } else {
        let at = email.indexOf("@");
        let dot = email.lastIndexOf(".");
        if (at < 1 || dot < at + 2 || dot == email.length - 1) errors.email = "Invalid email address";
    }

    if (phone.length == 0) {
        errors.phone = "Phone is required";
    } else {
        let digitsOnly = true;
        for (let i = 0; i < phone.length; i++) {
            let code = phone.charCodeAt(i);
            if (code < 48 || code > 57) digitsOnly = false;
        }
        if (!digitsOnly) errors.phone = "Phone must contain only digits";
        else if (phone.length != 10) errors.phone = "Phone must be exactly 10 digits";
        else if (phone.charAt(0) != "0") errors.phone = "Phone must start with 0";
    }

    if (!gender) errors.gender = "Gender is required";
    if (hobbies.length == 0) errors.hobbies = "At least one hobby is required";
    if (age == "") errors.age = "Age is required";
    if (teamname.length == 0) errors.teamname = "Team name is required";
    if (teamnumber.length == 0) errors.teamnumber = "Team number is required";

    document.querySelectorAll('.error').forEach(el => el.textContent = '');
    let hasError = false;
    for (let key in errors) {
        let span = document.getElementById(key + "Error");
        if (span) {
            span.textContent = errors[key];
            hasError = true;
        }
    }

    return !hasError;
}

function checkPasswordStrength(password) {
    let hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
    let special = "!@#$%^&*(){}.";
    for (let i = 0; i < password.length; i++) {
        let c = password.charAt(i);
        let code = password.charCodeAt(i);
        if (c == " ") return "Password cannot contain spaces";
        if (code >= 65 && code <= 90) hasUpper = true;
        else if (code >= 97 && code <= 122) hasLower = true;
        else if (code >= 48 && code <= 57) hasDigit = true;
        else if (special.indexOf(c) != -1) hasSpecial = true;
    }
    if (password.length < 6) return "Password must be at least 6 characters";
    if (!hasUpper) return "Password must contain an uppercase letter";
    if (!hasLower) return "Password must contain a lowercase letter";
    if (!hasDigit) return "Password must contain a digit";
    if (!hasSpecial) return "Password must contain a special character";
    return "";
}

function valLogin() {
    let errors = {};
    let username = document.getElementById("txtUsername").value;
    let password = document.getElementById("txtPassword").value;

    if (username.length == 0) errors.username = "Username is required";
    if (password.length == 0) errors.password = "Password is required";

    document.querySelectorAll('.error').forEach(el => el.textContent = '');
    let hasError = false;
    for (let key in errors) {
        let span = document.getElementById(key + "Error");
        if (span) { span.textContent = errors[key]; hasError = true; }
    }
    return !hasError;
}

function valNewPassword() {
    let errors = {};
    let password = document.getElementById("txtPassword").value;
    let newPassword = document.getElementById("txtNewPassword").value;

    if (password.length == 0) errors.password = "Current password is required";
    if (newPassword.length == 0) {
        errors.newPassword = "New password is required";
    } else {
        let msg = checkPasswordStrength(newPassword);
        if (msg != "") errors.newPassword = msg;
        else if (newPassword == password) errors.newPassword = "New password must be different from current password";
    }

    document.querySelectorAll('.error').forEach(el => el.textContent = '');
    let hasError = false;
    for (let key in errors) {
        let span = document.getElementById(key + "Error");
        if (span) { span.textContent = errors[key]; hasError = true; }
    }
    return !hasError;
}