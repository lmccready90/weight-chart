import { useEffect, useState } from 'react';
import axios from 'axios';

interface Unit {
    id: number
    symbol: string
    description: string
}
export default function Input() {

    const [units, setUnits] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5120/api/units')
            .then(response => {
                setUnits(response.data)
            })
    }, [])

    const Dropdown = units.map(
        (unit: Unit) => {
            return (
                <option value={unit.id}>{unit.symbol}</option>
            )
        }
    )
    return (
        <>
            <p>
                <select>
                    {Dropdown}
                </select>
                <input type="text" />
                <button>Save</button>
            </p>
        </>
    )
}
