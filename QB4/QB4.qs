namespace QuantumSample.QB4
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
	open Microsoft.Quantum.Convert;
	
	operation QB4Run (bitZero : Int, bitOne: Int, bitTwo: Int, bitThree: Int, bitFour: Int) : String
    {
		mutable probability = 0;
		mutable bit0 = bitZero;
		mutable bit1 = bitOne;
		mutable bit2 = bitTwo;
		mutable bit3 = bitThree;
		mutable bit4 = bitFour;
		using (qubits = Qubit[5])
		{
			for (test in 1..10000)
			{
				Set (Zero, qubits[0]);
				Set (Zero, qubits[1]);
				Set (Zero, qubits[2]);
				Set (Zero, qubits[3]);
				Set (Zero, qubits[4]);
				H(qubits[0]);
				H(qubits[1]);
				let heartRateMeasure = M (qubits[1]);
				if (heartRateMeasure == One) {
					H(qubits[2]);
				} 			
				H(qubits[3]);
				let respiratoryRateMeasure = M (qubits[3]);
				if(respiratoryRateMeasure == One) {
					H(qubits[4]);
				}
				let res0 = M (qubits[0]);
				let res1 = M (qubits[1]);
				let res2 = M (qubits[2]);
				let res3 = M (qubits[3]);
				let res4 = M (qubits[4]);
				if(res4 == Zero and res3 == Zero and res2 == Zero and res1 == Zero and res0 == Zero and
				bit4 == 0 and bit3 == 0 and bit2 == 0 and bit1 == 0 and bit0 == 0){set probability = probability + 1;}
				if(res4 == Zero and res3 == Zero and res2 == Zero and res1 == Zero and res0 == One and
				bit4 == 0 and bit3 == 0 and bit2 == 0 and bit1 == 0 and bit0 == 1){set probability = probability + 1;}
				if(res4 == Zero and res3 == Zero and res2 == Zero and res1 == One  and res0 == Zero and
				bit4 == 0 and bit3 == 0 and bit2 == 0 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				if(res4 == Zero and res3 == Zero and res2 == Zero and res1 == One  and res0 == One and
				bit4 == 0 and bit3 == 0 and bit2 == 0 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
						
				if(res4 == Zero and res3 == Zero and res2 == One  and res1 == One  and res0 == Zero and
				   bit4 == 0 and bit3 == 0 and bit2 == 1 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				if(res4 == Zero and res3 == Zero and res2 == One  and res1 == One  and res0 == One and
				bit4 == 0 and bit3 == 0 and bit2 == 1 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == Zero and res1 == Zero and res0 == Zero and
				   bit4 == 0 and bit3 == 1 and bit2 == 0 and bit1 == 0 and bit0 == 0){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == Zero and res1 == Zero and res0 == One and
				   bit4 == 0 and bit3 == 1 and bit2 == 0 and bit1 == 0 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == Zero and res1 == One and res0 == Zero and
				   bit4 == 0 and bit3 == 1 and bit2 == 0 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == Zero and res1 == One  and res0 == One and
				   bit4 == 0 and bit3 == 1 and bit2 == 0 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == One  and res1 == One  and res0 == Zero and
                   bit4 == 0 and bit3 == 1 and bit2 == 1 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				
				if(res4 == Zero and res3 == One  and res2 == One  and res1 == One  and res0 == One and
				   bit4 == 0 and bit3 == 1 and bit2 == 1 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == One and res3 == One  and res2 == Zero and res1 == Zero and res0 == Zero and
				bit4 == 1 and bit3 == 1 and bit2 == 0 and bit1 == 0 and bit0 == 0){set probability = probability + 1;}
				
				if(res4 == One and res3 == One  and res2 == Zero and res1 == Zero and res0 == One and
				bit4 == 1 and bit3 == 1 and bit2 == 0 and bit1 == 0 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == One and res3 == One  and res2 == Zero and res1 == One  and res0 == Zero and
				bit4 == 1 and bit3 == 1 and bit2 == 0 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				
				if(res4 == One and res3 == One  and res2 == Zero and res1 == One  and res0 == One and
				bit4 == 1 and bit3 == 1 and bit2 == 0 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
				
				if(res4 == One and res3 == One  and res2 == One  and res1 == One  and res0 == Zero and
				bit4 == 1 and bit3 == 1 and bit2 == 1 and bit1 == 1 and bit0 == 0){set probability = probability + 1;}
				if(res4 == One and res3 == One  and res2 == One  and res1 == One  and res0 == One  and
				   bit4 == 1 and bit3 == 1 and bit2 == 1 and bit1 == 1 and bit0 == 1){set probability = probability + 1;}
			}
			Set(Zero, qubits[0]);
			Set(Zero, qubits[1]);
			Set(Zero, qubits[2]);
			Set(Zero, qubits[3]);
			Set(Zero, qubits[4]);
		}
		set probability = probability/100;
		if(probability >=1 and probability<=4){
			Message("Priority -> "+  DoubleAsString(IntAsDouble(bit4))+ DoubleAsString(IntAsDouble(bit3))+ DoubleAsString(IntAsDouble(bit2))+ DoubleAsString(IntAsDouble(bit1))+ DoubleAsString(IntAsDouble(bit0))+" -> P1");
			return "P1";
		}
		
		if(probability >=5 and probability<=10){
			Message("Priority -> "+  DoubleAsString(IntAsDouble(bit4))+ DoubleAsString(IntAsDouble(bit3))+ DoubleAsString(IntAsDouble(bit2))+ DoubleAsString(IntAsDouble(bit1))+ DoubleAsString(IntAsDouble(bit0))+" ->  P2");
			return "P2";
		}
		
		if(probability >=11 and probability<=15){
			Message("Priority -> "+  DoubleAsString(IntAsDouble(bit4))+ DoubleAsString(IntAsDouble(bit3))+ DoubleAsString(IntAsDouble(bit2))+ DoubleAsString(IntAsDouble(bit1))+ DoubleAsString(IntAsDouble(bit0))+" ->  P3");
			return "P3";
		}
		if(probability <1 or probability>15){
			Message("Priority -> Invalid");
			return "NA";
		}

		return "NA";
    }
	operation Set (desired: Result, q1: Qubit) : Unit
    {
		let current = M(q1);
		if (desired != current)
		{
			X(q1);
		}
    }
}