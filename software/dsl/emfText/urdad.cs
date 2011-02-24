SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model

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
	"raises" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"BasicDataType" COLOR #7F0055, BOLD;
	"DataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"hasAttribute" COLOR #7F0055, BOLD;
	"ofType" COLOR #7F0055, BOLD;
	"isAssociatedWith" COLOR #7F0055, BOLD;
	"has" COLOR #7F0055, BOLD;
	"contains" COLOR #7F0055, BOLD;
	"QualityRequirement" COLOR #7F0055, BOLD;
	"isRequiredBy" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"checks" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"ensures" COLOR #7F0055, BOLD;
	"use" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"toAddress" COLOR #7F0055, BOLD;
	"ServiceContract" COLOR #7F0055, BOLD;
	"undoneVia" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"realizes" COLOR #7F0055, BOLD;
	"Process" COLOR #7F0055, BOLD;
	"doSequential" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"ifNot" COLOR #7F0055, BOLD;
	"doConcurrent" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"Concurrency" COLOR #7F0055, BOLD;
	"wait" COLOR #7F0055, BOLD;
	"until" COLOR #7F0055, BOLD;
	"requestService" COLOR #7F0055, BOLD;
	"handleException" COLOR #7F0055, BOLD;
	"via" COLOR #7F0055, BOLD;
	"raiseException" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"resultConstraint" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"forAll" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)* 
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | dataTypes | servicesContracts | services | constraints | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	Query ::= "Query" name[] (queryExpression);
	
	Constraint ::= "Constraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;
	
	
	Condition ::= "Condition" name[] (constraintExpression)?
      ("raises" (exception))?
	  ("(" (annotations)*")")?;
	
	QualityConstraint ::= "QualityConstraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;

	RangeMultiplicity ::= "["minOccurs[] "," maxOccurs[] "]";
	BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (annotations)*")")?;
	
	DataStructure ::= "DataStructure" name[] ("is" superType[])? "{"
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?"}";
	Exception ::= "Exception" name[] ("is" superType[])? "{" 
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?"}";
	
	Attribute ::= "hasAttribute" name[] "ofType" type[];
	Association ::= "isAssociatedWith" name[] "ofType" relatedType[] (multiplicityConstraint)?; 
	Aggregation ::= "has" name[] "ofType" relatedType[] (multiplicityConstraint)?; 
	Composition ::= "contains" name[] "ofType" relatedType[] (multiplicityConstraint)?;
	 
	QualityRequirement ::= "QualityRequirement" name[] qualityConstraint[]
		"isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
	  
	PreCondition ::= "PreCondition" name[] "checks" condition[]  
		"isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
	  
	PostCondition ::= "PostCondition" name[] "ensures" condition[]  
		"isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
 		
	FunctionalRequirement ::= "use" requiredService[]
		("if" condition[])?
	 	"toAddress" "("usedToAddress[]*")"
	  ("(" (annotations)*")")?;
	
	ServiceContract ::= "ServiceContract" name[] "{"
	 (preCondition)*
	 (postCondition)*
	 (qualityRequirements )*
	 ("undoneVia" inverseService[])?
	 "Request" request   
	 "Result" result 
	  ("(" (annotations)*")")?"}";
	  
	Service ::= "Service" name[] "realizes" realizedContract[] "{"
		(functionalRequirements)*
		(process)
	"}";  
	
	Process ::= "Process" (activity);
	
	ActivitySequence ::= "doSequential" "{" (activities)* "}"; 

	If ::= "if" condition[] "do" (activity);
	
	IfNot ::= "ifNot" condition[] "do" (activity);
	
	ConcurrentActivity ::= "doConcurrent" (activity) ("blocking" "=" blocking[])?;
	
	Concurrency ::= "Concurrency" "{" (concurrentActivities)* "}"; 
	
	Wait ::= "wait" "until" until[];
	
	RequestService ::= "requestService" requestedService[] 
		("{" (requestConstraints)* "}")?;

	ExceptionHandler ::= "handleException" exception[] "via" (activity);
		
	RaiseException ::= "raiseException" exception[]	
		("{" (exceptionConstraints)* "}")?;
		
	ReturnResult ::= "returnResult"	
		("{" "ResultConstraints:" (resultConstraints)* "}")?;
		
	While ::= "while" condition[] "do" (activity);	
		
	ForAll ::= "forAll" (query) "do" (activity); 	

	Annotation ::= "Note" language[] ":" content['"','"'];
}