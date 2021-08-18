<template>
  <div id="app">
    <v-app>
      <v-main>
      <v-container fluid ma-0 pa-0 fill-height>
        <v-layout row>
          <!-- <v-flex md2> 
              <Menu></Menu> 
          </v-flex>
          <v-flex md10> 
              <Content></Content>
          </v-flex> -->


          <Menu></Menu>
          <Content></Content>
        </v-layout>

      </v-container>

    </v-main>
    </v-app>

  </div>
</template>

<script>
import Menu from './components/layout/menu/Menu.vue'
import Content from './components/layout/content/Content.vue'
export default {
  name: 'App',
  components: {
    Menu,
    Content
  }
}
</script>

<style>
#app {
  
}
@font-face {
    font-family: notosans-regular;
    src: url('assets/Icon/font/notosans-regular.2cb88a13.woff2');
 }
 @font-face {
    font-family: notosans-bold;
    src: url('assets/Icon/font/notosans-bold.3ede5aff.woff2');
 }
 @font-face {
    font-family: notosans-italic;
    src: url('assets/Icon/font/notosans-italic.1c1aaac9.woff2');
 }
 @font-face {
    font-family: notosans-semibold;
    src: url('assets/Icon/font/notosans-semibold.df3e6dc4.woff2');
 }
 
 * {
    font-family: notosans-regular;
 }
table tbody tr {
    height: 30px;
}
 
body, html{
    margin:0px;
    height:100vh;
    overflow: hidden !important;
}

/* css cho scroll bar */
.scrollbar {
  float: left;
  overflow-y: scroll;
}

.force-overflow {
  min-height: 0px;
}

.scrollbar::-webkit-scrollbar,

/**  STYLE 1 */
.scrollbar::-webkit-scrollbar-thumb {
  border-radius: 10px;
  -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.3);
  background-color: #BBBBBB;
  width:5px;
  height: 5px;
}

.scrollbar::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
  border-radius: 10px;
  background-color: #ffffff;
}



:root{
  /* biến menu_width để thay đổi width cho menu */
  --menu_width: 52px;
}


/* css cho v-tooltip */

.tooltip {
  display: block !important;
  z-index: 10000;
}

.tooltip .tooltip-inner {
  background: #FF4747;
  color: white !important;
  border-radius: 16px;
  padding: 5px 10px 4px;
  height:30px;
  font-size: 13px;
  text-align: center;
}

.tooltip .tooltip-arrow {
  width: 0;
  height: 0;
  border-style: solid;
  position: absolute;
  margin: 5px;
  border-color: #FF4747;
}

.tooltip[x-placement^="top"] {
  margin-bottom: 5px;
}

.tooltip[x-placement^="top"] .tooltip-arrow {
  border-width: 5px 5px 0 5px;
  border-left-color: transparent !important;
  border-right-color: transparent !important;
  border-bottom-color: transparent !important;
  bottom: -5px;
  left: calc(50% - 5px);
  margin-top: 0;
  margin-bottom: 0;
}

.tooltip[x-placement^="bottom"] {
  margin-top: 5px;
}

.tooltip[x-placement^="bottom"] .tooltip-arrow {
  border-width: 0 5px 5px 5px;
  border-left-color: transparent !important;
  border-right-color: transparent !important;
  border-top-color: transparent !important;
  top: -5px;
  left: calc(50% - 5px);
  margin-top: 0;
  margin-bottom: 0;
}

.tooltip[x-placement^="right"] {
  margin-left: 5px;
}

.tooltip[x-placement^="right"] .tooltip-arrow {
  border-width: 5px 5px 5px 0;
  border-left-color: transparent !important;
  border-top-color: transparent !important;
  border-bottom-color: transparent !important;
  left: -5px;
  top: calc(50% - 5px);
  margin-left: 0;
  margin-right: 0;
}

.tooltip[x-placement^="left"] {
  margin-right: 5px;
}

.tooltip[x-placement^="left"] .tooltip-arrow {
  border-width: 5px 0 5px 5px;
  border-top-color: transparent !important;
  border-right-color: transparent !important;
  border-bottom-color: transparent !important;
  right: -5px;
  top: calc(50% - 5px);
  margin-left: 0;
  margin-right: 0;
}

.tooltip[aria-hidden='true'] {
  visibility: hidden;
  opacity: 0;
  transition: opacity .15s, visibility .15s;
}

.tooltip[aria-hidden='false'] {
  visibility: visible;
  opacity: 1;
  transition: opacity .15s;
}



/* css cho datebox */
.dx-datebox {
    max-width: 100%;
    height: 32px;
}
.dx-texteditor.dx-editor-outlined{
    border: 1px solid #BABEC5 !important;
}
.dx-texteditor.dx-state-hover {
    border: 1px solid #2ca01c !important;
}
.dx-state-focused{
    border: 1px solid #2ca01c !important;
}
.dx-calendar-navigator .dx-calendar-caption-button.dx-button .dx-button-content{
    color: #2ca01c !important;
}
.dx-calendar-navigator-next-month.dx-button .dx-icon, .dx-calendar-navigator-next-view.dx-button .dx-icon{
    color: #2ca01c !important; 
}
.dx-calendar-body td{
    padding:0px;
}
.dx-calendar-cell.dx-calendar-selected-date.dx-calendar-contoured-date, .dx-calendar-cell.dx-calendar-selected-date.dx-calendar-today.dx-calendar-contoured-date{
    -webkit-box-shadow: inset 0 0 0 1px #bebebe, inset 0 0 0 1000px #2ca01c !important;
    box-shadow: inset 0 0 0 1px #bebebe, inset 0 0 0 1000px #2ca01c !important;
}
.dx-calendar-navigator-previous-month.dx-button .dx-icon, .dx-calendar-navigator-previous-view.dx-button .dx-icon{
    color: #2ca01c !important;
}


/**custom checkbox */
input[type="checkbox"] {
    position: relative;
    cursor: pointer;
    width: 18px;
    height: 18px;
    margin: 10px 20px;
    margin-right: 5px;
}
input[type="checkbox"]:checked{
    transform: rotate(360deg);
    transition: 0.1s;
}
input[type="checkbox"]:not(:checked){
    transform: rotate(-360deg);
    transition: 0.1s;
}
input[type="checkbox"]:before {
    content: "";
    display: block;
    position: absolute;
    width: 18px;
    height: 18px;
    top: 0;
    left: 0;
    border: 1px solid #BABEC5;
    border-radius: 3px;
    background-color: white;
}
input[type="checkbox"]:checked:after {
    content: "";
    display: block;
    width: 6px;
    height: 10px;
    border: solid #2CA01C;
    border-width: 0 2px 2px 0;
    transform: rotate(45deg);
    position: absolute;
    left: 6px;
    top: 2px;
}
</style>