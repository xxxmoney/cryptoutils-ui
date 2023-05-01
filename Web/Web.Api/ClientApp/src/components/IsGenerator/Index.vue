<template>
    <TabView>
        <TabPanel header="Normal GF(p)">
            <Normal />
        </TabPanel>
        <TabPanel header="Advanced GF(2^n)">
            <Advanced />
        </TabPanel>
    </TabView>
</template>

<script>
import Normal from './Normal.vue';
import Advanced from './Advanced.vue';

export default {
    name: 'IsGenerator',
    components: {
        Normal,
        Advanced
    },
    setup () {

        return {}
    }
}
</script>
