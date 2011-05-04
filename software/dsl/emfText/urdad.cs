SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad/core>
START Model,Expression,urdad.constraint.InverseConstraint,urdad.constraint.AndConstraint,urdad.constraint.OrConstraint,urdad.constraint.XorConstraint,urdad.constraint.StateConstraint,urdad.constraint.StateConstraintReference,urdad.data.BasicDataType,urdad.data.DataStructure,urdad.contract.ResultRequirement,urdad.contract.ServiceContract,urdad.process.Service


IMPORTS {
	urdad.constraint:<http://www.urdad.org/2010/urdad/constraint>
	urdad.data:<http://www.urdad.org/2010/urdad/data>
	urdad.contract:<http://www.urdad.org/2010/urdad/contract>
	urdad.process:<http://www.urdad.org/2010/urdad/process>
}

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}

TOKENSTYLES {
	"Model" COLOR #7F0055, BOLD;
	"ResponsibilityDomain" COLOR #7F0055, BOLD;
	"Query" COLOR #7F0055, BOLD;
	"Constraint" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"FunctionalRequirements" COLOR #7F0055, BOLD;
	"receiving" COLOR #7F0055, BOLD;
	"yielding" COLOR #7F0055, BOLD;
	"StateConstraint" COLOR #7F0055, BOLD;
	"Parameter" COLOR #7F0055, BOLD;
	"StateAssessmentProcess" COLOR #7F0055, BOLD;
	"InverseConstraint" COLOR #7F0055, BOLD;
	"inverseOf" COLOR #7F0055, BOLD;
	"AndConstraint" COLOR #7F0055, BOLD;
	"AND" COLOR #7F0055, BOLD;
	"OrConstraint" COLOR #7F0055, BOLD;
	"OR" COLOR #7F0055, BOLD;
	"XorConstraint" COLOR #7F0055, BOLD;
	"XOR" COLOR #7F0055, BOLD;
	"from" COLOR #7F0055, BOLD;
	"to" COLOR #7F0055, BOLD;
	"many" COLOR #7F0055, BOLD;
	"BasicDataType" COLOR #7F0055, BOLD;
	"DataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"abstract" COLOR #7F0055, BOLD;
	"has" COLOR #7F0055, BOLD;
	"Variable" COLOR #7F0055, BOLD;
	"ofType" COLOR #7F0055, BOLD;
	"Constant" COLOR #7F0055, BOLD;
	"valueOf" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"Attribute" COLOR #7F0055, BOLD;
	"Identification" COLOR #7F0055, BOLD;
	"identifying" COLOR #7F0055, BOLD;
	"Association" COLOR #7F0055, BOLD;
	"linking" COLOR #7F0055, BOLD;
	"Aggregate" COLOR #7F0055, BOLD;
	"Component" COLOR #7F0055, BOLD;
	"QualityRequirement" COLOR #7F0055, BOLD;
	"requiredBy" COLOR #7F0055, BOLD;
	"with" COLOR #7F0055, BOLD;
	"constructedUsing" COLOR #7F0055, BOLD;
	"ResultConstraint" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"raises" COLOR #7F0055, BOLD;
	"checks" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"ensures" COLOR #7F0055, BOLD;
	"use" COLOR #7F0055, BOLD;
	"toAddress" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"ServiceContract" COLOR #7F0055, BOLD;
	"undoneUsing" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"realizes" COLOR #7F0055, BOLD;
	"doSequential" COLOR #7F0055, BOLD;
	"choice" COLOR #7F0055, BOLD;
	"else" COLOR #7F0055, BOLD;
	"doConcurrent" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"Concurrency" COLOR #7F0055, BOLD;
	"wait" COLOR #7F0055, BOLD;
	"until" COLOR #7F0055, BOLD;
	"create" COLOR #7F0055, BOLD;
	"set" COLOR #7F0055, BOLD;
	"equalTo" COLOR #7F0055, BOLD;
	"add" COLOR #7F0055, BOLD;
	"remove" COLOR #7F0055, BOLD;
	"requestService" COLOR #7F0055, BOLD;
	"on" COLOR #7F0055, BOLD;
	"raiseException" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"forAll" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)* 
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | constraints | dataTypes | servicesContracts | services | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	urdad.process.Query ::= "Query" (name[])? (queryExpression);
	
	urdad.constraint.ExpressionBasedConstraint ::= "Constraint" (name[])? (constraintExpression)? 
	  ("(" (annotations)*")")?;	
	
	urdad.constraint.QualityConstraint ::= "QualityConstraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;

	urdad.contract.FunctionalRequirements ::= "FunctionalRequirements"
		("receiving" (requestVariable))?
		("yielding" (resultVariable))? 
	"{"
		 (preConditions)*
		 (postConditions)*
	"}";

	urdad.constraint.StateConstraint ::= "StateConstraint" name[] ("receiving" (parameter))?
	"{"
	  ("Parameter" parameterDataStructure)? 	 
	  ("StateAssessmentProcess" (stateAssessmentProcess))?  
	  (constraints)* 
	"}";
	
	urdad.constraint.InverseConstraint ::= "InverseConstraint" name[] "inverseOf" operand[];
	urdad.constraint.AndConstraint ::= "AndConstraint" name[] "=" leftOperand[] "AND" rightOperand[];
	urdad.constraint.OrConstraint ::= "OrConstraint" name[] "=" leftOperand[] "OR" rightOperand[];
	urdad.constraint.XorConstraint ::= "XorConstraint" name[] "=" leftOperand[] "XOR" rightOperand[];
	
	urdad.data.RangeMultiplicity ::= "from" minOccurs[] "to" maxOccurs[];
	urdad.data.Many ::= "many";

	urdad.data.BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (constraints)*")")? ("(" (annotations)*")")?;  
	
	urdad.data.DataStructure ::= "DataStructure" name[] ("is" "("((superTypes[])+)")")? "{"
	  ("abstract" "=" abstract[])?
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";

	urdad.process.Variable ::= "Variable" name[] "ofType" type[];

	urdad.process.Constant ::= "Constant" value['"','"'];

	urdad.process.VariableReference ::= "valueOf" variable[];
	  
	urdad.contract.Exception ::= "Exception" name[] ("is" ((superTypes[])+))? "{" 
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";
	
	urdad.data.Attribute ::= (multiplicityConstraint)? "Attribute" name[] "ofType" type[];
	urdad.data.Identification ::= (multiplicityConstraint)? "Identification"  name[] "identifying" relatedElement[]; 
	urdad.data.Association ::= (multiplicityConstraint)? "Association"  name[] "linking" relatedElement[]; 
	urdad.data.Aggregation ::= (multiplicityConstraint)? "Aggregate" (multiplicityConstraint)? name[] "ofType" relatedElement[]; 
	urdad.data.Composition ::= (multiplicityConstraint)? "Component" (multiplicityConstraint)? name[] "ofType" relatedElement[];
	 
	urdad.contract.QualityRequirement ::= "QualityRequirement" name[] qualityConstraint[]? 
		"requiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;

	urdad.constraint.StateConstraintReference ::= "Constraint" constraint[] 
		("with" (parameter) ("constructedUsing" (parameterConstructionProcess))?)?; 
	
	urdad.contract.ResultRequirement ::= "ResultConstraint" constraintExpression;
	  
	urdad.contract.PreCondition ::= "PreCondition" name[]
	  "requiredBy" "("(requiredBy[])*")" 
      "raises" exception[] 
	  ("checks" stateConstraintReference)? 
	  ("(" (annotations)*")")?;
	  
	urdad.contract.PostCondition ::= "PostCondition" name[] 
		"requiredBy" "("(requiredBy[])*")"
	  ("ensures" stateConstraintReference)? 
	  ("(" (annotations)*")")?;
 		
	urdad.process.ServiceRequirement ::= "use" requiredService[]
	 	"toAddress" "("(usedToAddress[])*")"
		("if" (condition))? ("(" (annotations)*")")?;
	
	urdad.contract.ServiceContract ::= "ServiceContract" name[] "{"
	 (functionalRequirements)?
	 (qualityRequirements)*
	 ("undoneUsing" inverseService[])?
	 "Request" request   
	 "Result" result 
	  ("(" (annotations)*")")?"}";
	  
	urdad.process.Service ::= "Service" name[] "realizes" realizedContract[] "receiving" (requestVariable)
	"{"
		(serviceRequirements)*
		"Process " (process)
	"}";  
	
	urdad.process.ActivitySequence ::= "doSequential" (name[])? "{" (activities)* "}"; 

	urdad.process.If ::= "if" (condition) (activity);

	urdad.process.Choice ::= "choice" "{" (conditionalActivities)* ("else" (elseActivity)?) "}";
	
	urdad.process.ConcurrentActivity ::= "doConcurrent" (activity) ("blocking" "=" blocking[])?;
	
	urdad.process.Concurrency ::= "Concurrency" "{" (concurrentActivities)* "}"; 
	
	urdad.process.Wait ::= "wait" "until" (until);
	
	urdad.process.Create ::= "create" (producedVariable);
	
	urdad.process.Assign ::= "set" target "equalTo" source;
	urdad.process.Add ::= "add" source "to" target;
	urdad.process.Remove ::= "remove" target;
	
	urdad.process.RequestService ::= "requestService" requestedService[] "with" requestVariable[] 
			("yielding" (producedVariable))? 
		("{" 
			(exceptionHandlers)*
		"}")?;

	urdad.process.ExceptionHandler ::= "on" exception[] (activity);
		
	urdad.process.RaiseException ::= "raiseException" exception[] ("with" exceptionVariable[])?;	
		
	urdad.process.ReturnResult ::= "returnResult"	resultVariable[];
		
	urdad.process.While ::= "while" (condition) "do" (activity);	
		
	urdad.process.ForAll ::= "forAll" (query) "do" (activity); 	

	Annotation ::= "Note" language[] ":" content['"','"'];
}