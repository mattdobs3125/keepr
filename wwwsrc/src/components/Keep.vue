<template>
<div class="keeps row">

    
       <div class="col-12">

           <div v-for="keep in keeps" :key="keep.id">

            
    
            {{keep.name}}
        
        
          
        
            {{keep.description}}
            
          
        
        <img :src="keep.img">
            
            
            
           </div> 
           </div>
            


    
</div>
</template>



<script>
export default {
    
    props:["keep"],
    name:"keep",
    
    mounted(){
this.$store.dispatch('getKeeps')
    },
    computed:{
        keeps(){
           return this.$store.state.keeps;
        }
    },
     

}
</script>
<style scoped>
.h1{
    color: #FFF;
background-color: #333;
text-shadow: #FFF 0 -1px 4px, #ff0 0 -2px 10px, #ff8000 0 -10px 20px, red 0 -18px 40px;
}
</style>
