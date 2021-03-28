<template>
    <div>
        <h1>Hello World</h1>
        <v-footer class="pa-3" v-if="showFooter">
            <v-spacer></v-spacer>
            <div>© {{ new Date().getFullYear() }}, SuperCompany</div>
        </v-footer>
    </div>
</template>

<script src='./HomeLayout.ts'></script>
