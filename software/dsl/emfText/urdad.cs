SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad/core>
START Model,Expression,urdad.constraint.InverseCondition,urdad.constraint.AndCondition,urdad.constraint.OrCondition,urdad.constraint.XorCondition,urdad.constraint.StateCondition,urdad.data.Query,urdad.data.Constant,urdad.data.VariableReference,urdad.data.BasicDataType,urdad.data.DataStructure,urdad.data.Variable,urdad.contract.ResultConstraint,urdad.contract.ServiceContract


IMPORTS {
	urdad.constraint:<http://www.urdad.org/2010/urdad/constraint>
	urdad.data:<http://www.urdad.org/2010/urdad/data>
	urdad.contract:<http://www.urdad.org/2010/urdad/contract>
	urdad.process:<http://www.urdad.org/2010/urdad/process>
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
	"Condition" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"FunctionalRequirements" COLOR #7F0055, BOLD;
	"receiving" COLOR #7F0055, BOLD;
	"yielding" COLOR #7F0055, BOLD;
	"stateAssessmentProcess" COLOR #7F0055, BOLD;
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
	"ValueOf" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"attribute" COLOR #7F0055, BOLD;
	"association" COLOR #7F0055, BOLD;
	"identifying" COLOR #7F0055, BOLD;
	"aggregate" COLOR #7F0055, BOLD;
	"component" COLOR #7F0055, BOLD;
	"QualityRequirement" COLOR #7F0055, BOLD;
	"requiredBy" COLOR #7F0055, BOLD;
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
	"with" COLOR #7F0055, BOLD;
	"on" COLOR #7F0055, BOLD;
	"raiseException" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"forAll" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
	"constructedUsing" COLOR #7F0055, BOLD;
	"ConditionReference" COLOR #7F0055, BOLD;
	"annotations" COLOR #7F0055, BOLD;
	"constructConditionParameterProcess" COLOR #7F0055, BOLD;
	"parameter" COLOR #7F0055, BOLD;
	"condition" COLOR #7F0055, BOLD;
	"ResultConstraint" COLOR #7F0055, BOLD;
	"constraintExpression" COLOR #7F0055, BOLD;
	"NotCondition" COLOR #7F0055, BOLD;
	"operand" COLOR #7F0055, BOLD;
	"AndCondition" COLOR #7F0055, BOLD;
	"leftOperand" COLOR #7F0055, BOLD;
	"rightOperand" COLOR #7F0055, BOLD;
	"OrCondition" COLOR #7F0055, BOLD;
	"XorCondition" COLOR #7F0055, BOLD;
	"InverseCondition" COLOR #7F0055, BOLD;
	"inverseOf" COLOR #7F0055, BOLD;
	"AND" COLOR #7F0055, BOLD;
	"OR" COLOR #7F0055, BOLD;
	"XOR" COLOR #7F0055, BOLD;
	"TypeIdentifier" COLOR #7F0055, BOLD;
	"type" COLOR #7F0055, BOLD;
	"Identification" COLOR #7F0055, BOLD;
	"name" COLOR #7F0055, BOLD;
	"multiplicityConstraint" COLOR #7F0055, BOLD;
	"relatedType" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)* 
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | constraints | dataTypes | servicesContracts | services | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	urdad.data.Query ::= "Query" (name[])? (queryExpression);
	
	urdad.constraint.ExpressionBasedConstraint ::= "Constraint" (name[])? (constraintExpression)? 
	  ("(" (annotations)*")")?;	
	
	urdad.contract.QualityConstraint ::= "QualityConstraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;

	urdad.contract.FunctionalRequirements ::= "FunctionalRequirements"
		("receiving" (requestVariable))?
		("yielding" (resultVariable))? 
	"{"
		 (preConditions)*
		 (postConditions)*
	"}";

	urdad.constraint.StateCondition ::= "Condition" name[] ("receiving" (parameter))?
	"{" 
	  ("stateAssessmentProcess" (stateAssessmentProcess))?  
	  (stateConstraints)* 
	"}";
	
	urdad.constraint.InverseCondition ::= "InverseCondition" name[] "inverseOf" operand[];
	urdad.constraint.AndCondition ::= "AndCondition" name[] "=" leftOperand[] "AND" rightOperand[];
	urdad.constraint.OrCondition ::= "OrCondition" name[] "=" leftOperand[] "OR" rightOperand[];
	urdad.constraint.XorCondition ::= "XorCondition" name[] "=" leftOperand[] "XOR" rightOperand[];
	
	urdad.data.RangeMultiplicity ::= "from" minOccurs[] "to" maxOccurs[];
	urdad.data.Many ::= "many";

	urdad.data.BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (constraints)*")")? ("(" (annotations)*")")?;  
	
	urdad.data.DataStructure ::= "DataStructure" name[] ("is" superType[])? "{"
	  ("abstract" "=" abstract[])?
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";

	urdad.data.Variable ::= "Variable" name[] "ofType" type[];

	urdad.data.Constant ::= "Constant" value['"','"'];

	urdad.data.VariableReference ::= "ValueOf" variable[];
	  
	urdad.contract.Exception ::= "Exception" name[] ("is" superType[])? "{" 
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";
	
	urdad.data.Attribute ::= (multiplicityConstraint)? "attribute" name[] "ofType" type[];
	urdad.data.Identification ::= (multiplicityConstraint)? "identification"  name[] "identifying" relatedType[]; 
	urdad.data.Association ::= (multiplicityConstraint)? "association"  name[] "linking" relatedType[]; 
	urdad.data.Aggregation ::= (multiplicityConstraint)? "aggregate" (multiplicityConstraint)? name[] "ofType" relatedType[]; 
	urdad.data.Composition ::= (multiplicityConstraint)? "component" (multiplicityConstraint)? name[] "ofType" relatedType[];
	 
	urdad.contract.QualityRequirement ::= "QualityRequirement" name[] qualityConstraint[]? 
		"requiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;

	urdad.contract.ConditionConstraint ::= "condition" condition[] 
		("with" (parameter) ("constructedUsing" (stateAssessmentProcess))?)?; 
	
	urdad.contract.ResultConstraint ::= "ResultConstraint" constraintExpression;
	  
	urdad.contract.PreCondition ::= "PreCondition" name[]
	  "requiredBy" "("(requiredBy[])*")" 
      "raises" exception[] 
	  ("checks" conditionReference)? 
	  ("(" (annotations)*")")?;
	  
	urdad.contract.PostCondition ::= "PostCondition" name[] 
		"requiredBy" "("(requiredBy[])*")"
	  ("ensures" conditionReference)? 
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
		(activity)
	"}";  
	
	urdad.process.ActivitySequence ::= "doSequential" (name[])? "{" (activities)* "}"; 

	urdad.process.If ::= "if" (constraint) (activity);

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