<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="m" :min="0" v-model="data.m" class="w-full" />
                <label for="m">m</label>
            </span>
            
            <ErrorMessages :v="v$" field="m" />
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
                <InputNumber id="d" :min="0" v-model="data.d" class="w-full" />
                <label for="d">d</label>
            </span>
            
            <ErrorMessages :v="v$" field="d" />
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
        const algo = computed(() => mainStore.algorithms.Rsa);
        const data = computed(() => algo.value.data.decryption);

        const rules = {
            m: { required },
            n: { required },
            d: { required },
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync({
                decryption: data.value
            });
        };

        return {
            data,
            v$,
            isCurrentValid,
            getResultAsync
        }
    }
}
</script>
