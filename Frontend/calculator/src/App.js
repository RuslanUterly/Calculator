import React from 'react';
import { Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar.jsx';
import CalculatorBase from './components/pages/CalculatorBase.jsx';
import CalculatorExpression from './components/pages/CalculatorExpression.jsx';

function App() {
  return (
    <div className='flex flex-col min-h-screen gap-8 justify-center'>
      <NavBar />
      <Routes>
        <Route path="/" element={<CalculatorBase />} />
        <Route path="/expression" element={<CalculatorExpression />} />
      </Routes>
    </div>
  );
}

export default App;
