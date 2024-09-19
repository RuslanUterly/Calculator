import React from 'react';
import { Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar.jsx';
import CalculatorBase from './components/pages/CalculatorBase.jsx';
import CalculatorExpression from './components/pages/CalculatorExpression.jsx';

function App() {
  return (
    <div>
      <NavBar />
      <Routes>
        <Route path="/basic" element={<CalculatorBase />} />
        <Route path="/expression" element={<CalculatorExpression />} />
      </Routes>
    </div>
  );
}

export default App;
