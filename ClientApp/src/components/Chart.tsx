import { useEffect, useState } from 'react';
import { Chart } from "react-google-charts";
import axios from 'axios';

interface Log {
  date: string;
  weight: string;
}

export default function WeightChart() {

  const [logs, setLogs] = useState([]);

  const mappedData = logs.map((log: Log) => [new Date(log.date), log.weight]);
  const graphData = [["Date", "Weight"], ...mappedData];

  const options = {
    title: "Weight by Date",
    legend: { position: "bottom" },
    hAxis: {
      format: "MM/yy",
      textStyle:{color: '#BDC0FF'},
      gridlines: {color: '#1E4D6B'}
    },
    vAxis: {
      title: "Weight in lb",
      textStyle:{color: '#BDC0FF'},
      gridlines: {color: '#1E4D6B'}
    },
    lineWidth: 3,
    backgroundColor: '#121212',
    series: {0: {color: '#646cff'}}
  };


  useEffect(() => {
    axios.get('http://localhost:5120/api/weightlogs')
      .then(response => {
        setLogs(response.data)
      })
  }, [])


  return (
    <>
      <Chart
        chartType="LineChart"
        width="1000px"
        height="600px"
        data={graphData}
        options={options}
      />
    </>
  )
}
