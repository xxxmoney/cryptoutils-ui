<template>
    <TabView>
        <TabPanel header="Get Subjects">
            <GetSubjects />
        </TabPanel>
        <TabPanel header="Reconstruction">
            <Reconstruction />
        </TabPanel>    
    </TabView>
</template>

<script>
import GetSubjects from './GetSubjects.vue';
import Reconstruction from './Reconstruction.vue';

export default {
    name: 'ShamirProtocol',
    components: {
        GetSubjects,
        Reconstruction
    },
    setup () {

        return {}
    }
}
</script>
