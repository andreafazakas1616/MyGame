var currentElementBeingShown = 1;
showSlide(currentElementBeingShown);

function addValueToCurrentIndex(value)
{
    var newIndexToBeShown = currentElementBeingShown + value;

    showSlide(newIndexToBeShown);
}

function showSlideForIndex(newIndex)
{
    showSlide(newIndex);
}

function showSlide(slideIndex)
{
    var i;

    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");

    if (slideIndex > slides.length)
    {
        currentElementBeingShown = 1;
    }
    if (slideIndex < 1)
    {
        currentElementBeingShown = slides.length;
    }
    if (slideIndex >= 1 && slideIndex <= slides.length)
    {
        currentElementBeingShown = slideIndex;
    }

    for (i = 0; i < slides.length; i++)
    {
        slides[i].style.display = "none";

        dots[i].className = dots[i].className.replace(" active", "");
    }

    slides[currentElementBeingShown - 1].style.display = "block";
    dots[currentElementBeingShown - 1].className += " active";

}