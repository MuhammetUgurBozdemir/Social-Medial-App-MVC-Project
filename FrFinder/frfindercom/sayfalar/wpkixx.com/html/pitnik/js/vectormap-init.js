$(document).on('ready', function(){
    
    'use strict';
     
     //*** Map Jvector ***//
     $('#vector-map').vectorMap({
          map: 'usa_en',
         backgroundColor: '#ffffff',
         borderColor: '#818181',
         borderOpacity: 0.25,
         borderWidth: 0.25,
         color: '#c6d3e0',
         colors: {
             mo: '#a8b2bd',
             fl: '#a8b2bd',
             or: '#a8b2bd'
         },
         enableZoom: true,
         showLabels: false,
         hoverColor: '#b9c7d5',
         hoverOpacity: null,
         normalizeFunction: 'linear',
         scaleColors: ['#b6d6ff', '#005ace'],
         selectedColor: '#b9c7d5',
         selectedRegions: [],
         showTooltip: false,
         onRegionClick: function(element, code, region)
         {
             var message = 'You clicked "'
                 + region
                 + '" which has the code: '
                 + code.toUpperCase();

             alert(message);
         }
    });
});