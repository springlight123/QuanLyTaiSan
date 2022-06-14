<template>
<div id="app">
    <div class="row">
        <Menu />
        <div class="column">
            <Header />
            <router-view></router-view>
        </div>
    </div>
    <FormAsset />
</div>
</template>

<script>
import Menu from '@/components/layout/Menu.vue'
import Header from '@/components/layout/Header.vue'
import FormAsset from '@/components/layout/FormAsset.vue'

export default {
    name: 'App',
    components: {
        Menu,
        FormAsset,
        Header,
    },
    mounted(){
        let externalScript = document.createElement('script')
    externalScript.setAttribute('src', './js/Resources.js')
    }
}
</script>

<style>
@font-face {
    font-family: GoogleSans;
    src: url(./assets/font/GoogleSans.otf);
}

* {
    box-sizing: inherit;
    margin: 0;
    padding: 0;
    font-family: GoogleSans;
}

html {
    box-sizing: border-box;
    font-size: 62.5%;
}

.row {
    display: flex;
}

.column {
    display: flex;
    flex-flow: column;
    width: 100%;
}
</style>
