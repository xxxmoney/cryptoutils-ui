<template>
    <div class="relative">
        <Chips v-model="valuesComputed" separator="," @add="onAdd" v-tooltip="'Confirm by enter or comma.'" ref="chips" :class="{'p-invalid': !isValid}" />
    </div>
</template>

<script>
import { ref, computed } from 'vue';
import { useToast } from 'primevue/usetoast';

export default {
    props: {
        values: {
            type: Array,
            required: true,
            default: () => []
        },
        validation: {
            type: Function,
            required: false,
            default: (value) => true
        },
        validation_fail: {
            type: String,
            required: false,
            default: null
        }
    },
    setup (props, context) {
        const chips = ref(null);
        const isValid = ref(true);
        const toast = useToast();

        const valuesComputed = computed({
            get: () => props.values,
            set: (value) => context.emit('update:values', value)
        });

        const onAdd = async (event) => {
            const value = event.value[event.value.length - 1];
            const input = event.originalEvent.target;

            // Validates value.
            isValid.value = await props.validation(value);
            
            // If not valid, remove from values and set back to input.
            if (!isValid.value) {
                valuesComputed.value = valuesComputed.value.filter(v => v != value);
                input.value = value;
                // Show error toast.
                toast.add({ severity: 'error', summary: 'Error', detail: props.validation_fail == null ? "Input error" : props.validation_fail, life: 3500 });
            }
        }

        return {
            chips,
            valuesComputed,
            isValid,
            onAdd
        }
    }
}
</script>

