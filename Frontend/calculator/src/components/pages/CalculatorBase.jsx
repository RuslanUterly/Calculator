import React, { useState } from "react";

export default function Base() {
  const [firstValue, setFirstValue] = useState("");
  const [secondValue, setSecondValue] = useState("");
  const [operation, setOperation] = useState("add");
  const [error, setError] = useState("");
  const [result, setResult] = useState(null);

  const handleCalculation = async () => {
    try {
      const baseValue = parseFloat(firstValue);
      const value = parseFloat(secondValue);

      const response = await fetch(`https://localhost:7207/api/calculator/${operation}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          baseValue: baseValue,
          value: value
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
          className="block px-4 py-1 rounded-xl outline-none focus:shadow-lg"
          type="number"
          placeholder="Введите число"
          value={firstValue}
          onChange={(e) => setFirstValue(e.target.value)}
        />
        <select
          className="block px-4 py-1 rounded-xl focus: shadow-lg"
          value={operation}
          onChange={(e) => setOperation(e.target.value)}
        >
          <option value="add">Сложение</option>
          <option value="subtract">Вычитание</option>
          <option value="multiply">Умножение</option>
          <option value="divide">Деление</option>
          <option value="pow">Возведение в степень</option>
          <option value="root">Извелечение корня</option>
        </select>
        <input
          className="block px-4 py-1 rounded-xl outline-none focus:shadow-lg"
          type="number"
          placeholder="Введите число"
          value={secondValue}
          onChange={(e) => setSecondValue(e.target.value)}
        />
        <button
          className="py-2 items-start w-32 text-white text-lg bg-slate-400 rounded-xl hover:bg-slate-500 active:bg-slate-100"
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
