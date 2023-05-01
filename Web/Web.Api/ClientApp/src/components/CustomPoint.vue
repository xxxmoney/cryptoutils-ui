<template>
    <div class="grid grid-cols-2 gap-x-3 gap-y-2">
        <span v-if="label" class="text-lg col-span-2">{{ label }}</span>

        <div class="">
            <span class="p-float-label">
                <InputText :id="label + '_x'" :min="0" v-model="xComputed" class="w-full" />
                <label :for="label + '_x'">{{ labelX }}</label>
            </span>        

            <ErrorMessages :v="v" :field="field + '.x'" />     
        </div>

        <div class="">
            <span class="p-float-label">
                <InputText :id="label + '_y'" :min="0" v-model="yComputed" class="w-full" />
                <label :for="label + '_y'">{{ labelY }}</label>
            </span>   

            <ErrorMessages :v="v" :field="field + '.y'" />     
        </div>        
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
        },
        label: {
            type: String,
            required: true
        },
        labelX: {
            type: String,
            required: true
        },
        labelY: {
            type: String,
            required: true
        },
        x: {
            type: String,
            required: true
        },
        y: {
            type: String,
            required: true
        }
    },
    setup (props, context) {
        // Computeds for x and y with getter setter for emiting
        const xComputed = computed({
            get: () => props.x,
            set: (value) => context.emit('update:x', value)
        });
        const yComputed = computed({
            get: () => props.y,
            set: (value) => context.emit('update:y', value)
        });
        
        return {
            xComputed,
            yComputed
        }
    }
}
</script>
