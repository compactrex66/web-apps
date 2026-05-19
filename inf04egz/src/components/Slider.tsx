import { useCallback, useState } from 'react'

interface SliderProps {
    setColorValue: Function,
    letter: string
}

function Slider({setColorValue, letter}: SliderProps) {
    const [value, setValue] = useState(255);

    return (
        <div className='slider-element'>
            <span>{letter}</span>
            <input className='slider' type="range" min="0" max="255" value={value} onChange={(e) => { 
                setValue(Number(e.target.value));
                setColorValue(e.target.value) 
            }}/>
            <span>{value}</span>
        </div>
    )
}

export default Slider
