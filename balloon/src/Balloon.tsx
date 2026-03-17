import "./balloon.css"
import { useState } from "react"

export function Balloon() {
    const [size, changeSize] = useState(100)
    let radius = size / 2, defaultSize = 100;

    return (
        <div className="balloon" style={{width: size+"mm", height: size+"mm"}} onMouseDown={(e) => {
            if(e.button == 0)
                changeSize(size+10)
            else if(e.button == 2)
                changeSize(size-10)
            else
                changeSize(defaultSize)
        }}>
            Obwód = {Math.round(size * Math.PI * 100) / 100}mm
            <br />
            Pole = {Math.round(Math.pow(radius, 2) * Math.PI * 100) / 100}mm
        </div>
    )
}