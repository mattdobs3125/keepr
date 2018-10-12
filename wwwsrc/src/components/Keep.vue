<template>
<div class="keeps row">

    
       <div class="col-12">
<h1>Hello and welcome to Keepr the cool kids pinterest </h1>
           <div v-for="keep in keeps" :key="keep">
    
        <h1>
            {{keep}}
            </h1>
          
        <h1>
            {{keep}}
            </h1>
          
        <h1>
            {{keep}}
            </h1>
            
            
           </div> 
           </div>
            


    
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
    },
     

}
</script>
<style>

</style>
