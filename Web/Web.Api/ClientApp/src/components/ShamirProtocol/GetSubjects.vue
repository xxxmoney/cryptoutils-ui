<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="p" :min="0" v-model="data.p" class="w-full" />
                <label for="p">p</label>
            </span>
            
            <ErrorMessages :v="v$" field="p" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="k" :min="0" v-model="data.k" class="w-full" />
                <label for="k">k</label>
            </span>
            
            <ErrorMessages :v="v$" field="k" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="n" :min="0" v-model="data.n" class="w-full" />
                <label for="n">n</label>
            </span>
            
            <ErrorMessages :v="v$" field="n" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="s" :min="0" v-model="data.s" class="w-full" />
                <label for="s">s</label>
            </span>
            
            <ErrorMessages :v="v$" field="s" />
        </div>

        <div class="col-span-2 flex flex-col gap-7">      
            <Button label="+" @click="addItem()" />

            <div v-for="(point, index) in data.points" class="flex flex-row gap-2">
                <Point :v="v$" labelX="Point X" labelY="Point Y" v-model:x="point.x" v-model:y="point.y" class="col-span-2" />
                <Button label="-" class="p-button-danger mt-2" @click="removeItem(index)" />
            </div>
        </div>

        <Button :disabled="!isCurrentValid" label="Process" class="col-span-2" @click="getResultAsync()" />
    </div>
</template>

<script>
import { useMainStore } from '../../store/mainStore';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators'
import { computed, watch } from 'vue';

export default {
    setup () {
        const mainStore = useMainStore();        
        const algo = computed(() => mainStore.algorithms.ShamirProtocol);
        const data = computed(() => algo.value.data.getSubjects);

        const rules = {
            p: { required },
            k: { required },
            n: { required },
            s: { required }
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const removeItem = (index) => {
            data.value.points.splice(index, 1);
        };
        const addItem = () => {
            data.value.points.push({ x: null, y: null });
        };

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync({
                getSubjects: data.value
            });
        };

        return {
            data,
            v$,
            removeItem,
            addItem,
            isCurrentValid,
            getResultAsync
        }
    }
}
</script>
