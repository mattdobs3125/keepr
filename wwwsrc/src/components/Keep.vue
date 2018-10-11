<template>
<div class="keeps">

<h1>Hello and welcome to Keepr the cool kids pinterest </h1>
    
        <div v-for="keep in keeps" :key="keep"></div>
        <h1>
            {{keeps.name}}
            </h1>
        <h1>
            {{keeps.img}}
            </h1>
        <h1>
            {{keeps.description}}
            </h1>
            
            


    
</div>
</template>



<script>
export default {
    props:["keep"],
    name:"keep",
    computed:{
        keeps(){
           return this.$store.keeps;
        }
    }

}
</script>
<style>

</style>
