$(document).on('ready', function(){
    
  'use strict';

  var introguide = introJs();
  // var startbtn   = $('#startdemotour');
  introguide.setOptions({
   steps: [
   {
       element: '.main-menu > span',
       intro: 'Main Menu',
       position: 'left'
   },
   {
       element: '.ti-settings.main-menu',
       intro: 'General Settings',
       position: 'left'
   },
   {
       element: '.menu-small',
       intro: 'Compact Menu',
       position: 'right'
   },
   {
       element: '.add-loc',
       intro: 'Click Here to Share Location in the Post',
       position: 'top'
   },
   {
       element: '.top-search',
       intro: 'Search New People, Pages, Groups etc',
       position: 'bottom'
   },
   
   ]
  });
  introguide.start();

});