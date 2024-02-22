function playLottie(elem,source, dotNetHelper) {
    console.log('Lottie play');
    console.log(source);
   
    const readyListener = () => {
        console.log('Lottie ready');
        dotNetHelper.invokeMethodAsync('LottieReady');
        elem.removeEventListener('ready', readyListener);
    };
    elem.addEventListener('ready', readyListener, false);
    elem.load(source);
}