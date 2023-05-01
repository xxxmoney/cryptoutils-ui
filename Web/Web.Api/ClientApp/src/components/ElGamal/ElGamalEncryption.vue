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
                <InputNumber id="z" :min="0" v-model="data.z" class="w-full" />
                <label for="z">z</label>
            </span>
            
            <ErrorMessages :v="v$" field="z" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="b" :min="0" v-model="data.b" class="w-full" />
                <label for="b">b</label>
            </span>
            
            <ErrorMessages :v="v$" field="b" />
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
                <InputNumber id="m" :min="0" v-model="data.m" class="w-full" />
                <label for="m">m</label>
            </span>
            
            <ErrorMessages :v="v$" field="m" />
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
        const algo = computed(() => mainStore.algorithms.ElGamal);
        const data = computed(() => algo.value.data.encryption);

        const rules = {
            p: { required },
            z: { required },
            b: { required },
            k: { required },
            m: { required }
        };

        const v$ = useVuelidate(rules, data);

        watch(() => v$.value.$invalid, (value) => {
            algo.value.isValid = !value;
        });

        const isCurrentValid = computed(() => algo.value.isValid);  
        
        const getResultAsync = async () => {
            await mainStore.getResultAsync({
                encryption: data.value
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
