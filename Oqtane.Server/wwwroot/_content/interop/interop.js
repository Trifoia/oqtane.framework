
function scrollToElementInContainer(elementId, container, direction, offset) {
    const element = document.getElementById(elementId);

    if (element instanceof HTMLElement && container instanceof HTMLElement) {
        let elementPos = 0;
        if (direction === 'x') {
            elementPos = element.offsetLeft + offset;
            container.scrollTo(elementPos, 0);
        } else if (direction === 'y') {
            elementPos = element.offsetTop + offset;
            container.scrollTo(0, elementPos);
        }
    }
}

function triggerFileDownload(fileName, url) {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}

function updateViewportHeight() {
    const vh = window.innerHeight * 0.01;

    document.documentElement.style.setProperty('--vh', `${vh}px`);
}


updateViewportHeight();
window.addEventListener('resize', updateViewportHeight);
