import { helpers } from '@vuelidate/validators'

const isNumber = (value) => {
    return !isNaN(value);
}
const isNumberValidation = helpers.withMessage('Must be a number', isNumber);

const isBinary = (value) => {
    return /^[01]+$/.test(value);
}
const isBinaryValidation = helpers.withMessage('Must be a binary number', isBinary);

export { isNumber, isBinary, isNumberValidation, isBinaryValidation }
