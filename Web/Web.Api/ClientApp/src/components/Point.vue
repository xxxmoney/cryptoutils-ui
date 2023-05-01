<template>
    <div class="grid grid-cols-2 gap-x-3 gap-y-2">
        <span v-if="label" class="text-lg col-span-2">{{ label }}</span>

        <div class="">
            <span class="p-float-label">
                <InputNumber :id="label + '_x'" :min="0" v-model="xComputed" class="w-full" />
                <label :for="label + '_x'">{{ labelX }}</label>
            </span>        

            <ErrorMessages :v="v" :field="fieldX" />     
        </div>

        <div class="">
            <span class="p-float-label">
                <InputNumber :id="label + '_y'" :min="0" v-model="yComputed" class="w-full" />
                <label :for="label + '_y'">{{ labelY }}</label>
            </span>   

            <ErrorMessages :v="v" :field="fieldY" />     
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
            default: null
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
            type: Number,
            required: true
        },
        y: {
            type: Number,
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

        const fieldX = computed(() => props.field ? (props.field + '.x') : null);
        const fieldY = computed(() => props.field ? (props.field + '.y') : null);
        
        return {
            xComputed,
            yComputed,
            fieldX,
            fieldY
        }
    }
}
</script>
