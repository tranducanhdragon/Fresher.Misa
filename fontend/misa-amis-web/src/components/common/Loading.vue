<template>
    <div class="dialog-modal">
        <div class="loading-img rotating"></div>
    </div>
</template>
<script>

export default ({
    name:"Loading",
    data(){
        return{

        }
    },
    
    methods: {
        
    },
})
</script>
<style scoped>
.dialog-modal{
    width:100%;
    height:100%;
    background-color: rgba(0,0,0,0.3);
    position:absolute;
    left:0px;
    top:0px;
    /* opacity:50%; */
    z-index: 4;
}


/* Absolute Center Spinner */
.loading-img {
  position: fixed;
  z-index: 999;
  height: 2em;
  width: 2em;
  overflow: visible;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  background: url('../../assets/Icon/loading.svg') no-repeat center;
  background-size: auto;
}

/* animation rotating */
@keyframes rotating {
  from {
    -ms-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -webkit-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  to {
    -ms-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -webkit-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
.rotating {
  -webkit-animation: rotating 2s linear infinite;
  -moz-animation: rotating 2s linear infinite;
  -ms-animation: rotating 2s linear infinite;
  -o-animation: rotating 2s linear infinite;
  animation: rotating 2s linear infinite;
}
</style>