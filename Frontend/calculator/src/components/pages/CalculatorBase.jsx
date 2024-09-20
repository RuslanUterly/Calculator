import React, { useState } from "react";

export default function Base() {
  const [firstValue, setFirstValue] = useState("");
  const [secondValue, setSecondValue] = useState("");
  const [operation, setOperation] = useState("");
  const [error, setError] = useState("");
  const [result, setResult] = useState("");

  const handleCalculation = async () => {
    try {
      const a = parseFloat(firstValue);
      const b = parseFloat(secondValue);

      const requestBody = {
        add: { a, b },
        subtract: { a, b },
        multiply: { a, b },
        divide: { a, b },
        pow: { baseValue: a, exponent: b },
        root: { baseValue: a, exponent: b }
      }[operation];

      console.log(requestBody);

      const response = await fetch(`https://localhost:7207/api/calculator/${operation}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
      });

      const data = await response.text();

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
          className="block px-4 py-1 rounded-xl"
          type="number"
          placeholder="Введите число"
          value={firstValue}
          onChange={(e) => setFirstValue(e.target.value)}
        />
        <select
          className="block px-4 py-1 rounded-xl"
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
          className="block px-4 py-1 rounded-xl"
          type="number"
          placeholder="Введите число"
          value={secondValue}
          onChange={(e) => setSecondValue(e.target.value)}
        />
        <button
          className="py-2 items-start w-32 text-white text-lg bg-slate-400 rounded-xl"
          onClick={handleCalculation}
        >
          Расчет
        </button>
        {error && <div>{error}</div>}
        {result !== null && <div>{result}</div>}
      </div>
    </section>
  );
}
