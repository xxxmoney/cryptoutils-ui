<template>
    <Loading v-model:active="isLoading"
                :can-cancel="false"
                :is-full-page="true"/>
    <Toast position="top-right" />

    <header class="p-6">
        <ul class="flex flex-row items-center gap-4 m-auto max-w-6xl">
            <li>
                <!-- <router-link to="/"><img src="src/assets/vue.svg" alt="Logo" class="logo"></router-link> -->
            </li>
            <li class="flex-1"></li>
            <li>
                <router-link to="/"><span></span></router-link>
            </li>
        </ul>
    </header>

    <main class="flex-1">
        <router-view class="m-auto max-w-6xl" />
    </main>
    
    <footer>
        <ul class="m-auto max-w-6xl"></ul>
    </footer>
</template>

<script>
    import { useMainStore } from '../store/mainStore';
    import { computed } from 'vue';
    import Loading from 'vue-loading-overlay';
    import Toast from 'primevue/toast';

    export default {
        components: {
            Loading,
            Toast
        },
        setup () {
            const mainStore = useMainStore();
            const isLoading = computed({
                get: () => !mainStore.loaded,
                set: (value) => mainStore.loaded = !value
            });

            return {
                isLoading
            }
        }
    }
</script>

<style>
    #app {        
        padding-block: 1rem;

        display: flex;
        flex-direction: column;
        gap: 2.5rem;
    } 

    header {
        background-color: rgba(54, 54, 54, 0.5);

        border: 1px solid rgba(54, 54, 54, 0.5);
        border-radius: 0.1rem;
        box-shadow: 0 0 0 3px rgba(54, 54, 54, 0.3);        
    }

    .logo {
        width: 2.5rem;
        height: 2.5rem;
    }
</style>
