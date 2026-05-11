import { useEffect, useState } from 'react'
import './App.css'
import Slider from './components/Slider'

function App() {
    const [redValue, setRedValue] = useState(255)
    const [greenValue, setGreenValue] = useState(255)
    const [blueValue, setBlueValue] = useState(255)

    const [color, setColor] = useState(`${redValue}, ${greenValue}, ${blueValue}`)

    useEffect(() => {
        console.log(color)
        setColor(`${redValue}, ${greenValue}, ${blueValue}`);
    }, [redValue, greenValue, blueValue])

    return (
        <>
            <div className='color-rect' style={{
                backgroundColor: `rgb(${color})`
            }}></div>
            <span>Dobierz kolor suwakami i zapisz przyciskami</span>
            <Slider setColorValue={setRedValue} letter='R'></Slider>
            <Slider setColorValue={setGreenValue} letter='G'></Slider>
            <Slider setColorValue={setBlueValue} letter='B'></Slider>
            <button>Pobierz</button>
            <div></div>
        </>
    )
}

export default App
