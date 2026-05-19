import { useEffect, useState } from 'react'
import './App.css'
import Slider from './components/Slider'

function App() {
    const [redValue, setRedValue] = useState(255)
    const [greenValue, setGreenValue] = useState(255)
    const [blueValue, setBlueValue] = useState(255)

    const [color, setColor] = useState(`${redValue}, ${greenValue}, ${blueValue}`)
    const [labelColor, setLabelColor] = useState(`${redValue}, ${greenValue}, ${blueValue}`)

    useEffect(() => {
        console.log(color)
        setColor(`${redValue}, ${greenValue}, ${blueValue}`);
    }, [redValue, greenValue, blueValue])

    async function saveColorDB() {
        setLabelColor(`${redValue}, ${greenValue}, ${blueValue}`)

        const response = await fetch("http://localhost:5000/color", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                red: redValue,
                green: greenValue,
                blue: blueValue
            })
        })
    }

    return (
        <div className='container'>
            <div className='color-rect' style={{
                backgroundColor: `rgb(${color})`
            }}></div>
            <span className='left-aligned'>Dobierz kolor suwakami i zapisz przyciskami</span>
            <Slider setColorValue={setRedValue} letter='R'></Slider>
            <Slider setColorValue={setGreenValue} letter='G'></Slider>
            <Slider setColorValue={setBlueValue} letter='B'></Slider>
            <button onClick={saveColorDB}>Pobierz</button>
            <div className='color-label' style={{
                backgroundColor: `rgb(${labelColor})`
            }}>{labelColor}</div>
        </div>
    )
}

export default App
