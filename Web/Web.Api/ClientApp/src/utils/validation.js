import { helpers } from '@vuelidate/validators'

const isNumber = (value) => {
    return !isNaN(value);
}
const isNumberValidation = helpers.withMessage('Must be a number', isNumber);

const isBinary = (value) => {
    return /^[01]+$/.test(value);
}
const isBinaryValidation = helpers.withMessage('Must be a binary number', isBinary);

const isGroup = (value) => {
    return /^(g\^\d+|0)$/.test(value);
}
const isGroupValidation = helpers.withMessage('Must be group g^n or 0', isGroup);

export { isNumber, isBinary, isGroup, isNumberValidation, isBinaryValidation, isGroupValidation }
