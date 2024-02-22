
function playAnimation(elem, animationClass) {
    elem.addEventListener('animationend', () => {
        elem.removeEventListener('animationend', elem, false);
        elem.classList.remove(animationClass);
    }, false);

    elem.classList.add(animationClass);
}
