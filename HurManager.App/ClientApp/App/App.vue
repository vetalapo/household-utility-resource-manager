<template>
    <v-app class="app">
        <component v-bind:is="currentView"></component>
        <div v-if="loading" class="loading">
            <h1>Loading ...</h1>
        </div>
    </v-app>
</template>

<script src='./App.ts'></script>

<style scoped>
    .loading {
        z-index: 999;
        position: fixed;
        background-color: #FFF;
        width: 100%;
        height: 100%;
    }
</style>

<style>
    .el-picker-panel__body {
        font-family: "Roboto", "Helvetica Neue", sans-serif;
    }
</style>
