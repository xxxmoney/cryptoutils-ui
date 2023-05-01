<template>
        <TabView>
            <TabPanel header="Normal GF(p)">
                <NormalIndex />
            </TabPanel>
            <TabPanel header="Advanced GF(2^n)">
                <AdvancedIndex />
            </TabPanel>
        </TabView>
</template>

<script>
import NormalIndex from './Normal/NormalIndex.vue';
import AdvancedIndex from './Advanced/AdvancedIndex.vue';

export default {
    name: 'EllipticCurve',
    components: {
        NormalIndex,
        AdvancedIndex
    },
    setup () {

        return {}
    }
}
</script>
