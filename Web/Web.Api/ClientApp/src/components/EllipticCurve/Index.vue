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
import Normal from './Normal/Index.vue';
import Advanced from './Advanced/Index.vue';

export default {
    name: 'EllipticCurve',
    components: {
        Normal,
        Advanced
    },
    setup () {

        return {}
    }
}
</script>
