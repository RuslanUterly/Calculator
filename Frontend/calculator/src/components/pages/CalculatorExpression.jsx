import React, { useState } from "react";

export default function Expression() {
  const [expression, setExpression] = useState("");
  const [error, setError] = useState("");
  const [result, setResult] = useState(null);

  const handleCalculation = async () => {
    try {
      const response = await fetch(`https://localhost:7207/api/calculator/calculate`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          expression
        }),
      });

      const data = await response.text();

      if (!response.ok) {
        setResult(null);
        setError(data);
        return;
      }

      setResult(data);
      setError("");
      
    } catch (error) {
      setError(error.message);
      setResult(null);
    }
  };

  return (
    <section className="mx-auto w-96 bg-slate-200 rounded-xl">
      <div className="flex flex-col py-8 px-8 gap-4">
        <input 
            className="block px-4 py-2 rounded-xl"
            type="text" 
            placeholder="Введите выражение" 
            value={expression}
            onChange={e => setExpression(e.target.value)}
            />
        <button 
          className="py-2 items-start w-32 text-white text-lg bg-slate-400 rounded-xl"
          onClick={handleCalculation}
        >
          Расчет
        </button>
        {error && <div className="p-3 border-2 bg-red-200 border-red-600 rounded-xl">{error}</div>}
        {result !== null && <div className="p-3 border-2 bg-green-200 border-green-600 rounded-xl">{result}</div>}
      </div>
    </section>
  );
}
