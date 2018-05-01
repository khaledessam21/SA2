$(document).ready(function(){
    
   "use strict";
    
    $("html").niceScroll();
    $('.carousel').carousel({
   interval: 5000   
    }); 
    
    
    
    
    
    //button-top 
    
    var btn_top=$(".button-top");
    $(window).scroll(function () {
        
        $(this).scrollTop()>=700 ? btn_top.show():btn_top.hide();
       
        
    });
    
    btn_top.click(function (){
            
        $("html, body").animate({scrollTop : 0} , 2000);
        });
    
    
    //function load 
  
});