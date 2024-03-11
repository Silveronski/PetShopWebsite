document.addEventListener("DOMContentLoaded", () => {
    const inputErrors = document.querySelectorAll(".input-container span");
    const inputs = document.querySelectorAll(".form-input");  
    const form = document.querySelector("form");
    let hasErrors = false; 

    inputs[0].addEventListener("input", () => {
        if (isInputEmpty(inputs[0].value)) {
            inputErrors[0].textContent = "Please fill out the name!";
            inputErrors[0].style.display = "inline";
            hasErrors = true;
        }
        else if (!isInputConsistsOfLetters(inputs[0].value)) {
            inputErrors[0].textContent = "Name can only contain letters!";
            inputErrors[0].style.display = "inline";
            hasErrors = true;
        }
        else {
            inputErrors[0].style.display = "none";
            hasErrors = false;
        }
    });

    inputs[1].addEventListener("input", () => {
        if ((parseInt(inputs[1].value) <= 0 || (parseInt(inputs[1].value) > 50))) {
            inputErrors[1].textContent = "Age must be between 1 and 50!";
            inputErrors[1].style.display = "inline";
            hasErrors = true;
        }
        else if (inputs[1].value.length === 0) {
            inputErrors[1].textContent = "You must fill out the age!";
            inputErrors[1].style.display = "inline";
            hasErrors = true;
        }
        else {
            inputErrors[1].style.display = "none";
            hasErrors = false;
        }
    });


    inputs[2].addEventListener("input", () => {
        if (isInputEmpty(inputs[2].value)) {
            inputErrors[2].textContent = "Please fill out the description!";
            inputErrors[2].style.display = "inline";
            hasErrors = true;
        }
        else if (!isInputConsistsOfLetters(inputs[2].value)) {
            inputErrors[2].textContent = "Description can only contain letters!";
            inputErrors[2].style.display = "inline";
            hasErrors = true;
        }
        else {
            inputErrors[2].style.display = "none";
            hasErrors = false;
        }
    });

    inputs[3].addEventListener("input", () => {
        inputErrors[3].style.display = "none";
        hasErrors = false;
    });

    inputs[4].addEventListener("input", () => {
        inputErrors[4].style.display = "none";
        hasErrors = false;
    });


    function isInputEmpty(input) {
        if (input.trim() === "") {
            return true;
        }
        return false;
    }

    function isInputConsistsOfLetters(input) {
        const lettersRegex = /^[A-Za-z\s]+$/;
        return lettersRegex.test(input);
    }

    form.addEventListener("submit", (event) => {                         
        inputs.forEach((input, index) => {
            const errorIndex = index;
            if (input.value.trim() === "") {               
                if (inputs[3] !== input) {                    
                    inputErrors[errorIndex].style.display = "inline";
                    inputErrors[errorIndex].textContent = "Please fill out this field";
                    hasErrors = true;
                }                              
            }
        });

        if (hasErrors) {
            event.preventDefault();
        } 
    });   
});