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
        const errors = computed(() => props.v[props.field].$silentErrors);

        return {
            errors
        }
    }
}
</script>
