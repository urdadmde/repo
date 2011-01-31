SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model


TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


RULES {
	Model ::= "model" name[] "{" (responsibilityDomains)* "}";
	ResponsibilityDomain ::= "responsibilityDomain" name[] "{" "!<n>"
		"dataTypes" "{" "!<n>"
			(dataTypes)* "}" ";" "!<n>"
		"services" "{" "!<n>"
			(services)* "}"	";" "!<n>!"
		"functionalConstraints" "{" "!<n>"
			(functionalConstraints)* "}" ";" "!<n>"  			
		"qualityRequirements" "{" "!<n>"
			(qualityRequirements)* "}" ";" "!<n>" 
	"}";

	Expression ::= "{" "language=" language[]";" "expressionString=" expressionString[]";""}";
	DefinedConstraint ::= name[] "{" "!<n>"
		("constraintExpression" constraintExpression)? "}";	
	BooleanExpression ::= name[] "{"(constraintExpression)? "}";
	RangeMultiplicityConstraint ::= "rangeConstraint" name[] "["minOccurs[] "," maxOccurs[] "]" ";";
	BasicDataType ::= "datatype" name[] ";";
	DataStructure ::= "dataStructure" name[] ("is" superType[])? "{" (attributes)* (associations)* "}";
	Exception ::= "exception" name[] ("is" superType[])? "{" (attributes)* (associations)* "}";
	Attribute ::= "attribute" type[] ":" name[] ";";
	Association ::= "association" name[] ":" relatedType[] (multiplicityConstraint)? ";"; 
	Aggregation ::= "aggregation" name[] ":" relatedType[] (multiplicityConstraint)? ";"; 
	Composition ::= "composition" name[] ":" relatedType[] (multiplicityConstraint)? ";"; 
	QualityRequirement ::= "qualityRequirement" "{" "!<n>" 
		"requiredBy" requiredBy[]";""!<n>"
		(requirementExpression)? "}" ";";
	FunctionalRequirement ::= "functionalRequirement" "{" "!<n>"
		"requiredBy" requiredBy[] ";" "!<n>" ";"
	 	"functionalConstraint" functionalConstraint[] "}";
	
	PreCondition ::= "preCondition" name[] "{" "!<n>" 
		("constraintExpression" "'" constraintExpression "'" ";" "!<n>")?
		("requiredService" requiredService[] ";" "!<n>")?
		 "exception" exception[] "}";
	PostCondition ::= "postCondition" name[] "{" "!<n>"
		("constraintExpression" constraintExpression)?
		("requiredService" requiredService[] ";" "!<n>")?
		("inverseService" inverseService[] ";" "!<n>")? "}";
	
	Service ::= "service" name[] "{" "!<n>" 
	 "request" request ";" "!<n>"
	 "result" result ";" "!<n>" 
	 (functionalRequirements ";" "!<n>")+
	 (qualityRequirements[] ";" "!<n>")*
	 (process ";" "!<n>")? "}";
	Process ::= "process" processActivity;
	ActivitySequence ::= "activitySequence" ("background" "=" background[])? "{" "!<n>" (activities)* "}";
	ConcurrentActivities ::= "concurrentActivities" ("background" "=" background[])? "{" (activities)* "}";
	Switch ::= "switch" ("background" "=" background[])? "{" (conditionalActivities)* "}";
	
	While ::= "while" ("background" "=" background[])? "{" "!<n>"
		"condition" condition ";" "!<n>"
		"activity" activity ";" "!<n>" "}";
		
	ConditionalActivity ::= "conditionalActivity" ("background" "=" background[])? "{" "!<n>"
		"condition" condition ";" "!<n>"
		"activity" activity ";" "!<n>" "}";
	
	PreConditionActivity ::= "preConditionActivity" ("background" "=" background[])? "{" "!<n>" 
		("requestContraint" requestContraints ";" "!<n>")* 
		preCondition[] ";" "!<n>"
		("exceptionContraint" exceptionContraints ";" "!<n>")* "}";
	
	PostConditionActivity ::= "postConditionActivity"  ("background" "=" background[])? "{" "!<n>" 
		("requestContraint" requestContraints ";" "!<n>")* 
		postCondition[] ";" "!<n>"
		("inverseRequestContraint" inverseRequestContraints ";" "!<n>")* "}";
	
	PrePostConditionActivity ::= "prePostConditionActivity" ("background" "=" background[])? "{" "!<n>"
		("requestContraint" requestContraints ";" "!<n>")* 
		preCondition[] ";" "!<n>"
		postCondition[] ";" "!<n>"
		("exceptionContraint" exceptionContraints ";" "!<n>")* 
		("inverseRequestContraint" inverseRequestContraints ";" "!<n>")* "}";

	ReturnResultActivity ::= "returnResultActivity" ("background" "=" background[])? "{" "!<n>" 
		("resultContraint" resultContraints ";" "!<n>")* "}";
}