
//page loader ...
window.onload = function () {
    // Hide the loader after the page has fully loaded
    setTimeout(() => {
        document.getElementById("loader").style.display = "none";
    }, 3000);
    // Add the 'active' class to the element after the page has loaded
    //     const element = document.getElementById('animateMe');
    //   element.classList.add('active');
};
/**************************************************************************************************** */
// Disable scroll restoration to prevent the browser from remembering the scroll position
if ('scrollRestoration' in history) {
    history.scrollRestoration = 'manual';
}
/**************************************************************************************************** */
// this for lazy load ....
// Create an Intersection Observer to observe when the sections come into view
const sections = document.querySelectorAll('.section');
const observerOptions = {
    root: null, // Defaults to the viewport
    rootMargin: '0px',
    threshold: 0.2 // Trigger when 30% of the section is visible
};

const observer = new IntersectionObserver((entries, observer) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {

            // Add the 'loaded' class to the section when it is in view
            entry.target.classList.add('loaded');
            observer.unobserve(entry.target); // Stop observing the section after it has loaded
        }
    });
}, observerOptions);

// Observe each section
sections.forEach(section => {
    observer.observe(section);
});
/**************************************************************************************************** */
//make fixed navbar ...
window.onscroll = function () {
    const navbar = document.querySelector('.navbar');
    if (window.scrollY > 50) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }
};
/*************************************************************************************************** */
//document ready ...
$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        loop: true,
        margin: 10,
        rtl:true,
        nav: false,// Hide navigation controls (next/prev arrows)
        dots: false,// Optional: you can enable dots for navigation if needed
        autoplay: true,        // Enable autoplay
        autoplayTimeout: 3000,
        autoplayHoverPause: true,
        smartSpeed: 800,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    });
});
/*************************************************************************************************** */