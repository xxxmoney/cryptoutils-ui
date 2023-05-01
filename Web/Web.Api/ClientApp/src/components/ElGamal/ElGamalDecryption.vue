<template>
    <div class="custom-container">
        <div>
            <span class="p-float-label">
                <InputNumber id="c" :min="0" v-model="data.c" class="w-full" />
                <label for="c">c</label>
            </span>
            
            <ErrorMessages :v="v$" field="c" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="d" :min="0" v-model="data.d" class="w-full" />
                <label for="d">d</label>
            </span>
            
            <ErrorMessages :v="v$" field="d" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="p" :min="0" v-model="data.p" class="w-full" />
                <label for="p">p</label>
            </span>
            
            <ErrorMessages :v="v$" field="p" />
        </div>

        <div>
            <span class="p-float-label">
                <InputNumber id="a" :min="0" v-model="data.a" class="w-full" />
                <label for="a">a</label>
            </span>
            
            <ErrorMessages :v="v$" field="a" />
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
        const data = computed(() => algo.value.data.decryption);

        const rules = {
            c: { required },
            d: { required },
            p: { required },
            a: { required }
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
