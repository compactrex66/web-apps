import { useState } from 'react'
import { Balloon } from './Balloon'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Balloon></Balloon>
    </>
  )
}

export default App
