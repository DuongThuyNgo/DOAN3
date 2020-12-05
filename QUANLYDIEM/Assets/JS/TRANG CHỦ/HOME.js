var slideIndex = 0;
showSlides();
function showSlides() {
    var slides = document.getElementsByClassName("mySlides");
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";  
    }
    slideIndex++;
    if (slideIndex > slides.length) {slideIndex = 1}    
    slides[slideIndex-1].style.display = "block";  
    setTimeout(showSlides, 5000);
 }

 $(document).ready(function() {
    $(window).bind("scroll", function() {
            parallax();
    });
});
// Function tạo parallax effect
// tốc độ được quy định bởi biến speed - cái này thay đổi theo ý muốn
// scrollPos lấy vị trí hiện tại của thanh cuộn
function parallax() {
    var scrollPos = $(window).scrollTop(),
            speed = 0.2;
    $(".bg-dark").css("top", (0 - (scrollPos * speed)) + 'px');
}
               