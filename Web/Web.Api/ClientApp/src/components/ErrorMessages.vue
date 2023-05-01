<template>
    <div class="" v-for="error of errors" :key="error.$uid">
        <div class="text-red-500">{{ error.$message }}</div>
    </div>
</template>

<script>
import { computed } from 'vue';

export default {
    props: {
        v: {
            type: Object,
            required: true
        },
        field: {
            type: String,
            required: true
        }
    },
    setup (props) {
        const steps = props.field.split('.');
        let final = null;    

        // Use steps to go deeply into props.v.
        steps.forEach((step) => {
            if (final === null) {
                final = props.v[step];
            } else {
                final = final[step];
            }
        });
            
        const errors = computed(() => final.$silentErrors);

        return {
            errors
        }
    }
}
</script>
