function playLottie(elem,source, dotNetHelper) {   
    const readyListener = () => {
        dotNetHelper.invokeMethodAsync('LottieReady');
        elem.removeEventListener('ready', readyListener);
    };
    elem.addEventListener('ready', readyListener, false);
    elem.load(source);
}